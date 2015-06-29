defmodule Rosalind do
  defmodule Nucleotides do
    def count_single_nucleotide(base, counts) do
      base_atom = String.to_atom(base)
      Dict.put(counts, base_atom, Dict.fetch!(counts, base_atom) + 1)
    end
  
    def count_nucleotides(input) do
      Enum.reduce(String.codepoints(input),
                  %{:A => 0, :C => 0, :G => 0, :T => 0},
                  &count_single_nucleotide/2)
    end
  end
end
