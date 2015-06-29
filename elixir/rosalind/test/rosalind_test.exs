defmodule RosalindTest do
  use ExUnit.Case

  test "count nucleotides" do
    input = "AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC"
    expected = %{:A => 20, :C => 12, :G => 17, :T => 21}
    assert Rosalind.Nucleotides.count_nucleotides(input) == expected
  end

	test "transcribe dna to rna" do
		input =    "GATGGAACTTGACTACGTAAATT"
		expected = "GAUGGAACUUGACUACGUAAAUU"
		rslt = for n <- Rosalind.Transcribe.transcribe(input), into: "", do: n
		assert rslt == expected
	end
end
