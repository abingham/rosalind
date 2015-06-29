filename = Enum.fetch!(System.argv, 0)
data = to_string(File.read!(filename))
counts = Rosalind.Nucleotides.count_nucleotides(String.strip(data))
IO.puts "#{counts[:A]} #{counts[:C]} #{counts[:G]} #{counts[:T]}"
