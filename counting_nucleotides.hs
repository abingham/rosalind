import System.Environment

type Count = (Integer, Integer, Integer, Integer)

update :: Count -> Char -> Count
update (a, c, g, t) 'A' = (a + 1, c, g, t)
update (a, c, g, t) 'C' = (a, c + 1, g, t)
update (a, c, g, t) 'G' = (a, c, g + 1, t)
update (a, c, g, t) 'T' = (a, c, g, t + 1)
update (a, c, g, t) _ = (a, c, g, t)

countNucleotides :: String -> (Integer, Integer, Integer, Integer)
countNucleotides s = foldl update (0, 0, 0, 0) s

run :: String -> IO ()
run path = do
  contents <- readFile path
  putStrLn.show $ countNucleotides contents
  return ()

main :: IO ()
main = do
  args <- getArgs
  run (args !! 1)
