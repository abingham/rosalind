import Data.List (tails)

data Allele = Dom | Rec;

data Gene = Gene Allele Allele;

combinations :: Int -> [a] -> [[a]]
combinations 0 _  = [[]]
combinations n xs = [ y:ys | y:xs' <- tails xs
                           , ys <- combinations (n-1) xs']

-- |Produce a list of population constituents given a frequency description
population :: (Integer, Integer, Integer) -> [Gene]
population (0, 0, 0) = []
population (0, 0, n) = Gene Rec Rec : population (0, 0, n - 1)
population (0, n, m) = Gene Dom Rec : population (0, n - 1, m)
population (n, m, o) = Gene Dom Dom : population (n - 1, m, o)

reproduce [HomozygousDominant, _] = True
reproduce [_, HomozygousDominant] = True
reproduce [Heterozygous, _] = True
reproduce [_, Heterozygous] = True
reproduce _ = False

main = do
  putStrLn $ show $ fromIntegral (length dominant) / fromIntegral (length full)
  where
    full = map produceDominant $ combinations 2 $ population (2, 2, 2)
    dominant = filter (\x -> x) full
