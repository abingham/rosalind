defmodule Rosalind.Transcribe do
	def transcribe_base(base) when base == "T" do
		"U"
	end
	
	def transcribe_base(base) do
		base
	end
	
	def transcribe(dna) do
		String.codepoints(dna) |> Stream.map(&transcribe_base/1)
	end
end
