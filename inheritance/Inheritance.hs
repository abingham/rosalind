import Data.Ratio

data Gene = HD | H | HR

type Population = (Int, Int, Int)

-- |Calculate probability of dominant phenotype given two genes
dominant :: Gene -> Gene -> Ratio Int
dominant HD _ = 1
dominant _ HD = 1
dominant H H = 0.75
dominant H _ = 0.5
dominant _ H = 0.5
dominant _ _ = 0

-- |Calculate the probabilities of different parent genotype pairings
pairing :: Gene -> Gene -> Population -> Maybe (Ratio Int)
pairing HD HD pop@(k, m, n) = prob k (k - 1) pop
pairing HD H  pop@(k, m, n) = prob k m pop
pairing HD HR pop@(k, m, n) = prob k n pop
pairing H HD pop@(k, m, n) = prob m k pop
pairing H H  pop@(k, m, n) = prob m (m - 1) pop
pairing H HR pop@(k, m, n) = prob m n pop
pairing HR HD pop@(k, m, n) = prob n k pop
pairing HR H  pop@(k, m, n) = prob n m pop
pairing HR HR pop@(k, m, n) = prob n (n - 1) pop

-- |Calculate sub-probability for `pairing`.
prob :: Int -> Int -> Population -> Maybe (Ratio Int)
prob a b (m, n, o)
  | size < 2 = Nothing
  | otherwise = Just $ aProb * bProb
  where
    size = m + n + 0 :: Int
    aProb = a % size :: Ratio Int
    bProb = b % (size - 1) :: Ratio Int

main = do
  return ()
