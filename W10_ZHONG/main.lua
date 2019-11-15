require 'coin'



--https://www.runoob.com/lua/lua-data-types.html lua中文教程
--https://ebens.me/post/a-guide-to-getting-started-with-love2d/  love guide
--https://love2d.org/wiki/Tutorial:Callback_Functions  love wiki
--https://ebens.me/post/lua-for-programmers-part-1/  lua for programmers
mytable = {}


function love.load()
	width = 800
	height = 600

	coin1 = coin
	coin1.x = 200
	coin1.y = 200
	coin1.radius = 20
end

function love.update(dt)
end

function love.draw()

	love.graphics.setColor(255, 255, 255)
	love.graphics.rectangle("line", 200, 200, 400, 200)
	love.graphics.circle("fill", coin1.x, coin1.y, coin1.radius)

	if coin1.head then
    	love.graphics.setColor(0, 0, 0)
    	love.graphics.circle("fill", coin1.x, coin1.y, coin1.radius - 5)
    end
end

function love.mousepressed(x, y, button, istouch)

    if button == 1 then
       coin1:flip()
    end
end
	
function love.mousereleased(x, y, button, istouch)
end
