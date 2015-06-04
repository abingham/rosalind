import Data.List
import System.Environment (getArgs)

sublists :: [a] -> [[a]]
sublists [] = []
sublists l@(_:xs) = l : sublists xs

findMotif :: String -> String -> [Bool]
findMotif s t = map (\x -> isPrefixOf t x) $ sublists s

findMotifLocations :: String -> String -> [Int]
findMotifLocations s t = map (+ 1) $ findIndices (\x -> x) $ findMotif s t

processFile :: String -> IO ()
processFile filename = do
  contents <- readFile filename
  let (big:small:_) = lines contents
  putStrLn $ intercalate " " $ map show $ findMotifLocations big small

main :: IO ()
main = do
  args <- getArgs
  processFile (args !! 0)
