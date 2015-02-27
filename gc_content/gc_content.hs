import Data.List
import Data.List.Split
import System.Environment

-- I'm trying in place of taking the length of a filtered list in the
-- notional hope of avoiding having to fully instantiate the filtered2
-- list. Perhaps the compiler is smart enough to prevent that anyway.
countIf :: (a -> Bool) -> [a] -> Integer
countIf pred l = foldl (+) 0 $ map checker l
  where
    checker x
      | pred x = 1
      | otherwise = 0

gcContent :: [Char] -> Float
gcContent s = 100 * fromIntegral (countIf cOrG s) / fromIntegral (length s)
  where
    cOrG = (\b -> b == 'C' || b == 'G')

readGroups :: String -> [String]
readGroups l = filter (\s -> length s > 0) $ splitOn ">" l

parseGroup :: String -> (String, Float)
parseGroup s = (label, gcContent $ intercalate "" bases)
  where
    label:bases = splitOn "\n" s

maxContent traces = maximumBy comp $ map parseGroup $ readGroups traces
  where
    comp = (\(_, a) (_, b) -> compare a b)

printMaxContent filename = do
  traces <- readFile filename
  let (tag, content) = maxContent traces
  putStrLn tag
  putStrLn $ show content

main = do
  args <- getArgs
  printMaxContent $ args !! 0
