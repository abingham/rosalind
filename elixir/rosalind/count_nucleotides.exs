filename = Enum.fetch!(System.argv, 0)
{:ok, file} = File.open filename, [:read]
data = IO.read file, :all
File.close file
counts = Rosalind.Nucleotides.count_nucleotides String.strip(data)
IO.puts "#{counts[:A]} #{counts[:C]} #{counts[:G]} #{counts[:T]}"
