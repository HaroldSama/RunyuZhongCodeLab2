require 'coin'
require 'levels'
require 'chart'

text = "Hello World"
win = true
currentLevel = 0
maxLevel = 4
levelScale = 100
--scoreNeeded = 2
currentscore = 0
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

line = {
	p1 = 1,
	p2 = 2,
}

function love.load()
	width = 800
	height = 600
	love.window.setMode(width, height, {resizable=false})
    love.window.setTitle("Constellation Lighter")

    title = love.graphics.newImage('media/TitlePage.png')
    credit = love.graphics.newImage('media/Credit.png')

    makeLevels()
    makeCharts()

	--loadLevel()
end

function love.graphics.load()
    love.graphics.setFont(love.graphic.newFont(50))	
end

function love.draw()

	if currentLevel == 0 then
		love.graphics.draw(title)
		return
	end

	if currentLevel == maxLevel + 1 then
		love.graphics.draw(credit)
	    return
	end

    drawLevel(coins, triangles)

    for i in ipairs(charts) do
    	drawChart(charts[i])
    end

    love.graphics.setColor(255, 255, 255)
    love.graphics.print(text, 10, 10)
    love.graphics.print("Finished Charts: "..currentscore, 10, 30)
	--love.graphics.rectangle("line", 200, 200, 400, 200)
end

function love.mousepressed(x, y, button, istouch)

    if currentLevel == maxLevel + 1 then

      currentLevel = 0
      
      for i in ipairs(charts) do
      	charts[i].finished = false
      end

      for i in ipairs(levels) do
      	levels[i].finished = false
      	--[[for j in ipairs(levels[i].coins) do
      		coins[j].head = true
      	end]]
      end

      return
    end

    if win or currentLevel == 0 then
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

      for i in ipairs(charts) do
      	ChartFinished(charts[i])
      end

    end

    win = winning()

    if win then
      text = "Congratulation! Left click to progress."
    end
end
	
--[[function love.mousereleased(x, y, button, istouch)
	if button == 2 then
		loadLevel()
	end
end]]

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
  --[[for i in ipairs(coins) do
    if coins[i].head then
      return false
    end
  end

  return true]]
  if currentscore == levels[currentLevel].scoreNeeded then
  	return true
  end
end

function loadLevel()
  currentLevel = currentLevel + 1

  if currentLevel == maxLevel + 1 then
  	return
  end

  win = false
  coins, triangles, scoreNeeded, levelScale = levels[currentLevel].coins, levels[currentLevel].triangles, levels[currentLevel].scoreNeeded, levels[currentLevel].scale
  currentscore = 0
  
  for i in ipairs(coins) do
  	coins[i].head = true
  end

  if levels[currentLevel].transformed == false then
    transformLevel(coins, levels[currentLevel].originX, levels[currentLevel].originY, levelScale)
    levels[currentLevel].transformed = true
  end

  text = "Click inside a triangle to light/unlight the stars on it's vertices. Finish all "..tostring(scoreNeeded).." charts to win."
end

function transformLevel(coins, originX, originY, scale)
    for i in ipairs(coins) do
	  coins[i].x = coins[i].x * scale + originX
	  coins[i].y = coins[i].y * scale + originY
	  coins[i].radius = 20
	end    
end

function drawLevel(coins, triangles)

	for i in ipairs(triangles) do
	  love.graphics.setColor(255, 255, 255)
	  love.graphics.line(coins[triangles[i].v1].x, coins[triangles[i].v1].y, 
	  	                 coins[triangles[i].v2].x, coins[triangles[i].v2].y, 
	  	                 coins[triangles[i].v3].x, coins[triangles[i].v3].y, 
	  	                 coins[triangles[i].v1].x, coins[triangles[i].v1].y)
	end

	for i in ipairs(coins) do

	  love.graphics.setColor(255, 255, 255)

	  love.graphics.circle("fill", coins[i].x, coins[i].y, coins[i].radius)

	  if coins[i].head then
	  	love.graphics.setColor(0, 0, 0)
        love.graphics.circle("fill", coins[i].x, coins[i].y, coins[i].radius - 5)
      end

	end    
end

function drawChart(chart)

	if chart.levelBasedOn ~= currentLevel then
		return
	end

	love.graphics.setColor(255, 255, 255)

	for i in ipairs(chart.stars) do
		if chart.stars[i] == true then
		  love.graphics.circle("fill", (coins[i].x - levels[currentLevel].originX) * chart.scale / levelScale + chart.originX, 
			                           (coins[i].y - levels[currentLevel].originY) * chart.scale / levelScale + chart.originY, 
			                           coins[i].radius / 5)
		end
    end

    for i in ipairs(chart.lines) do
    	love.graphics.line((coins[chart.lines[i][1]].x - levels[currentLevel].originX) * chart.scale / levelScale + chart.originX, 
    		               (coins[chart.lines[i][1]].y - levels[currentLevel].originY) * chart.scale / levelScale + chart.originY,
    		               (coins[chart.lines[i][2]].x - levels[currentLevel].originX) * chart.scale / levelScale + chart.originX, 
    		               (coins[chart.lines[i][2]].y - levels[currentLevel].originY) * chart.scale / levelScale + chart.originY)
    end

    love.graphics.rectangle("line", chart.originX - 20, chart.originY - 20, chart.sizeX * chart.scale + 40, chart.sizeY * chart.scale + 40)

    if chart.finished == true then
    	love.graphics.rectangle("line", chart.originX - 25, chart.originY - 25, chart.sizeX * chart.scale + 50, chart.sizeY * chart.scale + 50)
    end

    love.graphics.print(chart.name, chart.originX, chart.originY + chart.sizeY * chart.scale + 30)
end

function ChartFinished(chart)

	if chart.levelBasedOn ~= currentLevel then
		return
	end

    if chart.finished == true then
    	return
    end

	for i in ipairs(coins) do
		if coins[i].head == chart.stars[i] then
			return
		end
	end

	chart.finished = true
	currentscore = currentscore + 1
end