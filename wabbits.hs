wabbits factor = map fst $ iterate (\(n0, n1) -> (n1, n0 * factor + n1)) (1, 1)

wabbitCount factor months = last $ take months $ wabbits factor
