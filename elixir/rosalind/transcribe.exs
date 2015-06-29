import Rosalind.Transcribe

filename = Enum.fetch!(System.argv, 0)
data = to_string(File.read!(filename))
rslt = for n <- transcribe(String.strip(data)), into: "", do: n
IO.puts rslt
