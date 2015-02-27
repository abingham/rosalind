import System.Environment

comp :: Char -> Char
comp 'A' = 'T'
comp 'T' = 'A'
comp 'C' = 'G'
comp 'G' = 'C'
comp x = x

complement :: String -> String
complement = (map comp).reverse

main :: IO ()
main = do
  args <- getArgs
  contents <- readFile (args !! 0)
  putStrLn $ complement contents
