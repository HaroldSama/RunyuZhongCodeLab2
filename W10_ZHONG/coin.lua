coin = {
	x = 0,
	y = 0,
	radius = 20,
	head = true,
	--value = 25
}

function coin:flip()
    self.head = not self.head
end

--[[function coin.flip(coin)
--    coin.head = not coin.head
--end
function coin:makeCoin(coinX, coinY)
    
    local self = setmetatable({}, coin)

    self.x = coinX
    self.y = coinY

    return self
end]]






