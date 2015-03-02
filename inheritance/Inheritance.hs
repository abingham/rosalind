import Data.List (tails)

data Gene = HD | H | HR

type Population = (Int, Int, Int)

-- |Calculate probability of dominant phenotype given two genes
dominant :: Gene -> Gene -> Float
dominant HD _ = 1
dominant _ HD = 1
dominant H H = 0.75
dominant H _ = 0.5
dominant _ H = 0.5
dominant _ _ = 0

-- |Calculate the probabilities of different parent genotype pairings
pairing :: Gene -> Gene -> Population -> Maybe Float
pairing HD HD pop@(k, m, n) = prob k (k - 1) pop
pairing HD H  pop@(k, m, n) = prob k m pop
pairing HD HR pop@(k, m, n) = prob k n pop
pairing H HD pop@(k, m, n) = prob m k pop
pairing H H  pop@(k, m, n) = prob m (m - 1) pop
pairing H HR pop@(k, m, n) = prob m n pop
pairing HR HD pop@(k, m, n) = prob n k pop
pairing HR H  pop@(k, m, n) = prob n m pop
pairing HR HR pop@(k, m, n) = prob n (n - 1) pop

count (m, n, o) = m + n + o
prob a b pop = (a / count) *  (b / (count - 1))

main = do
  putStrLn $ show $ fromIntegral (length dominant) / fromIntegral (length full)
  where
    full = map produceDominant $ combinations 2 $ population (2, 2, 2)
    dominant = filter (\x -> x) full
