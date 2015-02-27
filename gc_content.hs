test_data = unlines [
  ">Rosalind_6404",
  "CCTGCGGAAGATCGGCACTAGAATAGCCAGAACCGTTTCTCTGAGGCTTCCGGCCTTCCC",
  "TCCCACTAATAATTCTGAGG",
  ">Rosalind_5959",
  "CCATCGGTAGCGCATCCTTAGTCCAATTAAGTCCCTATCCAGGCGCTCCGCCGAAGGTCT",
  "ATATCCATTTGTCAGCAGACACGC",
  ">Rosalind_0808",
  "CCACCCTCGTGGTATGGCTAGGCATTCAGGAACCGGAGAACGCTTCAGACCAGCCCGGAC",
  "TGGGAACCTGCGGGCAGTAGGTGGAAT"
  ]

-- I'm trying in place of taking the length of a filtered list in the
-- notional hope of avoiding having to fully instantiate the filtered
-- list. Perhaps the compiler is smart enough to prevent that anyway.
countIf :: (a -> Bool) -> [a] -> Integer
countIf pred l = foldl (+) 0 $ map checker l
  where
    checker x
      | pred x = 1
      | otherwise = 0

gcContent :: [Char] -> Float
gcContent s = fromIntegral (countIf cOrG s) / fromIntegral (length s)
  where
    cOrG = (\b -> b == 'C' || b == 'G')

parseInput :: String -> [String]
parseInput l = foldl split [] $ (lines l)
  where
    split acc line
      | (head line) == '>' = "" : line : acc
      | (otherwise) = ((head acc) ++ line) : (tail acc)
