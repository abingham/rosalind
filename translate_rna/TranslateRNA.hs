import Data.List.Split

data AminoAcid = A | C | D | E | F | G | H | I | K | L | M | N | P | Q | R | S | T | V | W | Y | Stop
               deriving (Read, Show)

data RNABase = RNA_A | RNA_C | RNA_G | RNA_U
             deriving (Show)

instance Read RNABase where
  readsPrec _ ('A':rest) = [(RNA_A, rest)]
  readsPrec _ ('C':rest) = [(RNA_C, rest)]
  readsPrec _ ('G':rest) = [(RNA_G, rest)]
  readsPrec _ ('U':rest) = [(RNA_U, rest)]

type RNACodon = (RNABase, RNABase, RNABase)

rnaCodon :: RNACodon -> AminoAcid
rnaCodon (RNA_U, RNA_U, RNA_U) = F
rnaCodon (RNA_C, RNA_U, RNA_U) = L
rnaCodon (RNA_A, RNA_U, RNA_U) = I
rnaCodon (RNA_G, RNA_U, RNA_U) = V
rnaCodon (RNA_U, RNA_U, RNA_C) = F
rnaCodon (RNA_C, RNA_U, RNA_C) = L
rnaCodon (RNA_A, RNA_U, RNA_C) = I
rnaCodon (RNA_G, RNA_U, RNA_C) = V
rnaCodon (RNA_U, RNA_U, RNA_A) = L
rnaCodon (RNA_C, RNA_U, RNA_A) = L
rnaCodon (RNA_A, RNA_U, RNA_A) = I
rnaCodon (RNA_G, RNA_U, RNA_A) = V
rnaCodon (RNA_U, RNA_U, RNA_G) = L
rnaCodon (RNA_C, RNA_U, RNA_G) = L
rnaCodon (RNA_A, RNA_U, RNA_G) = M
rnaCodon (RNA_G, RNA_U, RNA_G) = V
rnaCodon (RNA_U, RNA_C, RNA_U) = S
rnaCodon (RNA_C, RNA_C, RNA_U) = P
rnaCodon (RNA_A, RNA_C, RNA_U) = T
rnaCodon (RNA_G, RNA_C, RNA_U) = A
rnaCodon (RNA_U, RNA_C, RNA_C) = S
rnaCodon (RNA_C, RNA_C, RNA_C) = P
rnaCodon (RNA_A, RNA_C, RNA_C) = T
rnaCodon (RNA_G, RNA_C, RNA_C) = A
rnaCodon (RNA_U, RNA_C, RNA_A) = S
rnaCodon (RNA_C, RNA_C, RNA_A) = P
rnaCodon (RNA_A, RNA_C, RNA_A) = T
rnaCodon (RNA_G, RNA_C, RNA_A) = A
rnaCodon (RNA_U, RNA_C, RNA_G) = S
rnaCodon (RNA_C, RNA_C, RNA_G) = P
rnaCodon (RNA_A, RNA_C, RNA_G) = T
rnaCodon (RNA_G, RNA_C, RNA_G) = A
rnaCodon (RNA_U, RNA_A, RNA_U) = Y
rnaCodon (RNA_C, RNA_A, RNA_U) = H
rnaCodon (RNA_A, RNA_A, RNA_U) = N
rnaCodon (RNA_G, RNA_A, RNA_U) = D
rnaCodon (RNA_U, RNA_A, RNA_C) = Y
rnaCodon (RNA_C, RNA_A, RNA_C) = H
rnaCodon (RNA_A, RNA_A, RNA_C) = N
rnaCodon (RNA_G, RNA_A, RNA_C) = D
rnaCodon (RNA_U, RNA_A, RNA_A) = Stop
rnaCodon (RNA_C, RNA_A, RNA_A) = Q
rnaCodon (RNA_A, RNA_A, RNA_A) = K
rnaCodon (RNA_G, RNA_A, RNA_A) = E
rnaCodon (RNA_U, RNA_A, RNA_G) = Stop
rnaCodon (RNA_C, RNA_A, RNA_G) = Q
rnaCodon (RNA_A, RNA_A, RNA_G) = K
rnaCodon (RNA_G, RNA_A, RNA_G) = E
rnaCodon (RNA_U, RNA_G, RNA_U) = C
rnaCodon (RNA_C, RNA_G, RNA_U) = R
rnaCodon (RNA_A, RNA_G, RNA_U) = S
rnaCodon (RNA_G, RNA_G, RNA_U) = G
rnaCodon (RNA_U, RNA_G, RNA_C) = C
rnaCodon (RNA_C, RNA_G, RNA_C) = R
rnaCodon (RNA_A, RNA_G, RNA_C) = S
rnaCodon (RNA_G, RNA_G, RNA_C) = G
rnaCodon (RNA_U, RNA_G, RNA_A) = Stop
rnaCodon (RNA_C, RNA_G, RNA_A) = R
rnaCodon (RNA_A, RNA_G, RNA_A) = R
rnaCodon (RNA_G, RNA_G, RNA_A) = G
rnaCodon (RNA_U, RNA_G, RNA_G) = W
rnaCodon (RNA_C, RNA_G, RNA_G) = R
rnaCodon (RNA_A, RNA_G, RNA_G) = R
rnaCodon (RNA_G, RNA_G, RNA_G) = G

-- map (\(a:b:c:_) -> (a,b,c)) $ chunksOf 3 testData

main = do
  return ()

-- Test data
testData :: String
testData = "AUGGCCAUGGCGCCCAGAACUGAGAUCAAUAGUACCCGUAUUAACGGGUGA"
testRNA = map (\(a:b:c:_) -> rnaCodon (a,b,c)) $ chunksOf 3 $ map (\x -> read [x]) testData
