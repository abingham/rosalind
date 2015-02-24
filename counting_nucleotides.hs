import Data.List
import System.Environment

type Count = (Integer, Integer, Integer, Integer)

update :: Count -> Char -> Count
update (a, c, g, t) 'A' = (a + 1, c, g, t)
update (a, c, g, t) 'C' = (a, c + 1, g, t)
update (a, c, g, t) 'G' = (a, c, g + 1, t)
update (a, c, g, t) 'T' = (a, c, g, t + 1)
update (a, c, g, t) _ = (a, c, g, t)

countNucleotides :: String -> Count
countNucleotides s = foldl update (0, 0, 0, 0) s

processFile :: String -> IO Count
processFile path = do
  contents <- readFile path
  return (countNucleotides contents)

toString :: Count -> String
toString (a, b, c, d) = intercalate " " $ map show [a, b, c, d]

main :: IO ()
main = do
  args <- getArgs
  count <- processFile (args !! 0)
  putStrLn $ toString count
  return ()
