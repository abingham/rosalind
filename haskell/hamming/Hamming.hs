-- |Calculate the hamming distance between two strings.
hamming :: String -> String -> Int
hamming a b = length $ filter (False ==) $ zipWith (==) a b

main = do
  putStrLn $ show $ hamming (testData !! 0) (testData !! 1)

-- Test stuff
testData = [
  "CGAGAGTACACATAACCCTGCCAGCGTGGTCGCCTGATAAGGACGTCGAAGAAATAATACGCCTGGTACGTGCTGGGGATGGCCGGTCGGCTCTAAGATACCCGATTTCGGATACAGACGACTAGAACACTGCCGATCACTATGCGTTTCTATGGCGGGCGGAGAACGCTATAGCATAGGCTCGTAACTTACAGGAGATGTTACTTCTCGCAGACCGGAGCATTGATATTGCCGGTCCCGGAATATACCTGTTGTTTAGTACCGCAAAATATCTTTTTAATAATTCTTCCACCAGTCTGCAGACTGCTAGCAATCAGCAGCGGTTTGGGCTTAGGCTTGTTCGTGTACAGGATCGCCCATCAATTCAAACTGACCCCACTCGTGGAGAGCAGCACAGCCCGATTATTGTATCGTAACCTAGTTGATTTTTTCGCACCCTAATCTTCTAATCACCCCTTGGTCGACTCGCCGCTCATTCTCTGTGTGGCTTCTGGATGAAGTAAAGGACATCCTCTCCTATAAAAGTATTGGATTCGGAATCACGGGACCATTTTAGATACAGGGCACGTAGCCCGAAGCGCATACACCCCAGTTGTCGTTAGATCTTGGCGCGACATCGGCATGACATACGGTTAGGCACATATCACACTGCTGTAGTTGATAGCGACTTTGCTGGACACAGATGAGGATGTGAGGTTGACTAGCGTGTAGTCCTTTGGCGTCGTGAGGTCACCTACTTTGCCTTCCCTGGGTCCGTAGTAGGTGGCCTAATGATCTAGACGCCTCTAAGATGCTGGCAAGAGAGGTATTGTAGCTTCGTAGCTAAAATGTCGGCGGTATCTTTCAGCACGTCCGATACGGGGGCCATGCAATACGATTCGATCGGTAGTGTAGTCGGGGTTCTTTAAGGGGCCCCACATTTCTCAAGAGATTTTAGTCTACCCACTGACTAACAACCTCCGCGTCACAAGACGCGAAGGAACGGACCATCACAG",
  "CGAGGGTATGAGCAACGCCGAAGCGTGGTACTACACATTGGAACGTCCTAGAAATCATTCGCCTTCAACGCGCGGCGGGGAGACCATTGATTCCATTAGATCTAGTTTCAGCTATAGTGACTAATAATTAGCAAATTGCCCCGATGTCATTATCATGCTTGTATAAGGCAACACCGTGTGCTCGTTTCTTAAATAAGATTCTACTGCGTGCCGATCCGAGCTTTGCTCTCGACTGTCGCGTAACCTAGGATTTATACGCGACCTCAAAAGTTCGCACTATCCATGCTCCCATGATTCTCCTTCGTACACCGTGCTATCAGCCTATGGGTCAATGAGGTCATTCTAGAGACGTCCACACAGGACACTACACCTACAGCGCCTACGGAGAGTAGCAGAGCCCGCCAATCTGAACGTGACATACTAGATATTTAGGCCCCAGGCTTTTATCTTCCCACCGAGGTCTCCTACCGATCTATGCGGCGTATGGGGTCTAGATTACCTAAGCGAGAGCCTCGCATGCCTTGGAATTTGAATACGTATACCGGCATGACGTTCTACACAGCGCGTCTATTTCTTGACGGATTCAACGCATTTCTCGTCCTACTTGGGTCCTACCAATCCATGATCGCGCACAAGACTGGTAACACTCTTCAGTCCTGGACGGCTTACCGGATGCTCTTACAGGGGCCAAACGCAATCTCCGGGAAGAGTGCCCTATCTTTGATGCAGGCGGTCTAAGTGTAGGTCATGGTACCGGAAGAGAGCGCTAGAAGCGCTAGACGCGTATTCGGTGCGCTGGATAGTGTGATCTAAGACTAGGCGCTAAAATGTCTTCGGTAACCTCGCCTGTATCGGCACCGTCGTACAAGCGCTACATGTCGCGGCTTGGTATAGCATCGGATACTAAGTCCCTGGCAGAGCTCTCGGGATAAGATGATGTGCCCGTGCACAAAACCCCTCCGAGGACCATGCTGTGAACGGCCCGTCCCGTGCAC"
  ]