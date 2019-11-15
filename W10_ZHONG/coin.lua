coin = {
	x = 0,
	y = 0,
	radius = 10,
	head = true,
	value = 25
}

function coin:flip()
    self.head = not self.head
end

--function coin.flip(coin)
--    coin.head = not coin.head
--end




