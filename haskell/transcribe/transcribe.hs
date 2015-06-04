import System.Environment

replace 'T' = 'U'
replace x = x

transcribe dna = map replace dna

processFile path = do
  contents <- readFile path
  return (transcribe contents)

main = do
  args <- getArgs
  output <- processFile (args !! 0)
  putStrLn output
