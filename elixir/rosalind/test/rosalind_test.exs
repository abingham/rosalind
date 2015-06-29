defmodule RosalindTest do
  use ExUnit.Case

  test "count nucleotides" do
    input = "AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC"
    expected = %{:A => 20, :C => 12, :G => 17, :T => 21}
    assert Rosalind.Nucleotides.count_nucleotides(input) == expected
  end
end
