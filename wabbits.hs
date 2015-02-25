wabbits factor = 1 : 1 : zipWith (\n0 n1 -> n0 * factor + n1) (wabbits factor) (drop 1 (wabbits factor))

wabbitCount months factor = last $ take months $ wabbits factor
