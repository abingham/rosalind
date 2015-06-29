import Rosalind.Nucleotides

filename = Enum.fetch!(System.argv, 0)
data = to_string(File.read!(filename))
%{:A => a, :C => c, :G => g, :T => t} = count_nucleotides(String.strip(data))
IO.puts "#{a} #{c} #{g} #{t}"
