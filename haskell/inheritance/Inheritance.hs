import Data.Foldable
import Data.Ratio
import Data.Sequence

data Gene =
  HD | H | HR
  deriving (Show)

type Population = (Int, Int, Int)

allPairings :: [[Gene]]
allPairings = map toList $ replicateM 2 [HD, HR, H]

-- |Calculate probability of dominant phenotype given two genes
dominant :: Gene -> Gene -> Ratio Int
dominant HD _ = 1
dominant _ HD = 1
dominant H H = 0.75
dominant H _ = 0.5
dominant _ H = 0.5
dominant _ _ = 0

-- |Calculate the probabilities of different parent genotype pairings
pairing :: Gene -> Gene -> Population -> Ratio Int
pairing HD HD pop@(k, _, _) = prob k (k - 1) pop
pairing HD H  pop@(k, m, _) = prob k m pop
pairing HD HR pop@(k, _, n) = prob k n pop
pairing H HD pop@(k, m, _) = prob m k pop
pairing H H  pop@(_, m, _) = prob m (m - 1) pop
pairing H HR pop@(_, m, n) = prob m n pop
pairing HR HD pop@(k, _, n) = prob n k pop
pairing HR H  pop@(_, m, n) = prob n m pop
pairing HR HR pop@(_, _, n) = prob n (n - 1) pop

-- |Calculate sub-probability for `pairing`.
prob :: Int -> Int -> Population -> Ratio Int
prob a b (m, n, o)
  | size < 2 = 0 % 1
  | otherwise = aProb * bProb
  where
    size = m + n + o :: Int
    aProb = a % size :: Ratio Int
    bProb = b % (size - 1) :: Ratio Int

-- |Calculate the probability of an offspring having the dominant phenotype.
probOfDominant :: Population -> Float
probOfDominant pop = fromIntegral (numerator fullProb) / fromIntegral (denominator fullProb)
  where
    pairingProbs = map (\[a, b] -> pairing a b pop) allPairings :: [Ratio Int]
    domProbs = map (\[a, b] -> dominant a b) allPairings :: [Ratio Int]
    fullProb = Prelude.sum $ Prelude.zipWith (*) pairingProbs domProbs

main :: IO ()
main = do
  putStrLn $ show $ probOfDominant (21, 30, 19)
  return ()
