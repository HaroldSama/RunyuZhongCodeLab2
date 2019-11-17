require 'coin'
require 'levels'

text = "Hello World"
win = false
currentLevel = 0
maxLevel = 4

--https://www.runoob.com/lua/lua-data-types.html lua中文教程
--https://ebens.me/post/a-guide-to-getting-started-with-love2d/  love guide
--https://love2d.org/wiki/Tutorial:Callback_Functions  love wiki
--https://ebens.me/post/lua-for-programmers-part-1/  lua for programmers

coins = {}
triangles = {}

triangle = {
	v1 = 1,
	v2 = 2,
	v3 = 3
}

function love.load()
	width = 800
	height = 600
	love.window.setMode(width, height, {resizable=false})
    love.window.setTitle("Constellation Lighter")

	loadLevel()
end

function love.update(dt)
end

function love.draw()

	for i in ipairs(triangles) do
	  love.graphics.setColor(255, 255, 255)
	  love.graphics.line(coins[triangles[i].v1].x, coins[triangles[i].v1].y, coins[triangles[i].v2].x, coins[triangles[i].v2].y, coins[triangles[i].v3].x, coins[triangles[i].v3].y, coins[triangles[i].v1].x, coins[triangles[i].v1].y)
	end

    love.graphics.print(text, 10, 10)
	--love.graphics.rectangle("line", 200, 200, 400, 200)

	for i in ipairs(coins) do
	  love.graphics.setColor(255, 255, 255)
	  love.graphics.circle("fill", coins[i].x, coins[i].y, coins[i].radius)
	  if coins[i].head then
	  	love.graphics.setColor(0, 0, 0)
        love.graphics.circle("fill", coins[i].x, coins[i].y, coins[i].radius - 5)
      end  
	end
end

function love.mousepressed(x, y, button, istouch)

    if win then
      loadLevel()
      return
    end

    --text = ""

    if button == 1 then
      local triangleHit = getTriangleHit(x, y)
      if triangleHit == nil then
      	return
      end
      --text = tostring(triangleHit.v1)..tostring(triangleHit.v2)..tostring(triangleHit.v3)
      coins[triangleHit.v1]:flip()
      coins[triangleHit.v2]:flip()
      coins[triangleHit.v3]:flip()
    end

    win = winning()

    if win then
      text = "You Win!"
    end
end
	
function love.mousereleased(x, y, button, istouch)
end

function shallowcopy(orig)
    local orig_type = type(orig)
    local copy
    if orig_type == 'table' then
        copy = {}
        for orig_key, orig_value in pairs(orig) do
            copy[orig_key] = orig_value
        end
    else -- number, string, boolean, etc
        copy = orig
    end
    return copy
end

function getTriangleHit(hitX, hitY)
  for i in ipairs(triangles) do
  	if posInTriangle(hitX, hitY, triangles[i]) then
  		return triangles[i]
  	end
  end
end

function posInTriangle(posX, posY, tri)
    
  local v1X = coins[tri.v1].x
  local v1Y = coins[tri.v1].y
  local v2X = coins[tri.v2].x
  local v2Y = coins[tri.v2].y
  local v3X = coins[tri.v3].x
  local v3Y = coins[tri.v3].y

  return sameSide(posX, posY, v1X, v1Y, v2X, v2Y, v3X, v3Y) and sameSide(posX, posY, v2X, v2Y, v1X, v1Y, v3X, v3Y) and sameSide(posX, posY, v3X, v3Y, v2X, v2Y, v1X, v1Y)
end

function sameSide(pX1, pY1, pX2, pY2, vX1, vY1, vX2, vY2)
  if vX2 == vX1 then
  	return (pX1 > vX1) == (pX2 > vX1)
  end
  
  local slope = (vY2 - vY1) / (vX2 - vX1)
  local intercept = vY1 - slope * vX1
  return (pY1 > slope * pX1 + intercept) == (pY2 > slope * pX2 + intercept)
end

function winning()
  for i in ipairs(coins) do
    if coins[i].head then
      return false
    end
  end

  return true
end

function loadLevel()
  currentLevel = currentLevel % maxLevel + 1
  win = false
  coins, triangles = makeLevel(currentLevel)
  text = "Click inside a triangle to light/unlight the stars on it's vertices. Light all stars to win."
end

