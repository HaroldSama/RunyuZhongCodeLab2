levels = {}

level = {
	coins,
	triangles,
	originX = 100,
	originY = 100,
	scale = 100,
	charts,
	scoreNeeded,
	finished = false,
	transformed = false
}
--function love.load()
    --coinsLevel1, trianglesLevel1 = makeLevel(1)
--end

function makeLevels()
	for i = 1, 4 do
		levels[i] = shallowcopy(level)
		levels[i].coins, levels[i].triangles, levels[i].scoreNeeded = makeLevel(i)
	end

	levels[3].scale = 150
	levels[4].originX = 50
	levels[4].originY = 150
end


function makeLevel(level)

  local coins = {}
  local triangles = {}
  local charts

  --------------------------------------------------------------lv1
  if level == 1 then

  	charts = 2

  	for i = 1, 7 do
      coins[i] = shallowcopy(coin)
	end

    coins[1].x = 0
    coins[1].y = 0

    coins[2].x = 0
    coins[2].y = 2

	coins[3].x = 2
	coins[3].y = 2

	coins[4].x = 0
	coins[4].y = 4

	coins[5].x = 2
	coins[5].y = 4

	coins[6].x = 4
	coins[6].y = 4

	coins[7].x = 4
	coins[7].y = 0

	for i = 1, 6 do
	  triangles[i] = shallowcopy(triangle)
	end

	triangles[1].v1 = 1
	triangles[1].v2 = 2
	triangles[1].v3 = 3

	triangles[2].v1 = 2
	triangles[2].v2 = 3
	triangles[2].v3 = 4

	triangles[3].v1 = 3
	triangles[3].v2 = 4
	triangles[3].v3 = 5

	triangles[4].v1 = 3
	triangles[4].v2 = 5
	triangles[4].v3 = 6

	triangles[5].v1 = 1
	triangles[5].v2 = 3
	triangles[5].v3 = 7

    triangles[6].v1 = 3
	triangles[6].v2 = 6
	triangles[6].v3 = 7
  end


  -----------------------------------------------------------------lv2
  if level == 2 then

    charts = 2

  	for i = 1, 7 do
      coins[i] = shallowcopy(coin)
	end

    coins[1].x = 4
    coins[1].y = 1

    coins[2].x = 4
    coins[2].y = 4

	coins[3].x = 2
	coins[3].y = 2

	coins[4].x = 2
	coins[4].y = 3

	coins[5].x = 0
	coins[5].y = 1

	coins[6].x = 0
	coins[6].y = 4

	coins[7].x = 2
	coins[7].y = 0

	for i = 1, 7 do
	  triangles[i] = shallowcopy(triangle)
	end

	triangles[1].v1 = 1
	triangles[1].v2 = 2
	triangles[1].v3 = 3

	triangles[2].v1 = 2
	triangles[2].v2 = 3
	triangles[2].v3 = 4

	triangles[3].v1 = 1
	triangles[3].v2 = 3
	triangles[3].v3 = 5

	triangles[4].v1 = 3
	triangles[4].v2 = 5
	triangles[4].v3 = 6

	triangles[5].v1 = 3
	triangles[5].v2 = 4
	triangles[5].v3 = 6

	triangles[6].v1 = 2
	triangles[6].v2 = 4
	triangles[6].v3 = 6

	triangles[7].v1 = 1
	triangles[7].v2 = 5
	triangles[7].v3 = 7
  end


  ----------------------------------------------------------------------lv3
  if level == 3 then

  	charts = 4

  	for i = 1, 8 do
      coins[i] = shallowcopy(coin)
	end

    coins[1].x = 1
    coins[1].y = 0

    coins[2].x = 0
    coins[2].y = 1

	coins[3].x = 1
	coins[3].y = 1

	coins[4].x = 2
	coins[4].y = 1

	coins[5].x = 0
	coins[5].y = 2

	coins[6].x = 1
	coins[6].y = 2

	coins[7].x = 2
	coins[7].y = 2

	coins[8].x = 1
	coins[8].y = 3

	for i = 1, 8 do
	  triangles[i] = shallowcopy(triangle)
	end

	triangles[1].v1 = 1
	triangles[1].v2 = 2
	triangles[1].v3 = 3

	triangles[2].v1 = 1
	triangles[2].v2 = 3
	triangles[2].v3 = 4

	triangles[3].v1 = 2
	triangles[3].v2 = 5
	triangles[3].v3 = 6

	triangles[4].v1 = 2
	triangles[4].v2 = 3
	triangles[4].v3 = 6

	triangles[5].v1 = 3
	triangles[5].v2 = 6
	triangles[5].v3 = 7

	triangles[6].v1 = 3
	triangles[6].v2 = 4
	triangles[6].v3 = 7

	triangles[7].v1 = 5
	triangles[7].v2 = 6
	triangles[7].v3 = 8

	triangles[8].v1 = 6
	triangles[8].v2 = 7
	triangles[8].v3 = 8
  end


  --------------------------------------------------------------------------lv4
  if level == 4 then

    charts = 6

  	for i = 1, 10 do
      coins[i] = shallowcopy(coin)
	end

    coins[1].x = 1
    coins[1].y = 0

    coins[2].x = 3
    coins[2].y = 0

	coins[3].x = 0
	coins[3].y = 1

	coins[4].x = 2
	coins[4].y = 1

	coins[5].x = 4
	coins[5].y = 1

	coins[6].x = 1
	coins[6].y = 2

	coins[7].x = 3
	coins[7].y = 2

	coins[8].x = 0
	coins[8].y = 3

	coins[9].x = 2
	coins[9].y = 3

	coins[10].x = 4
	coins[10].y = 3

	for i = 1, 11 do
	  triangles[i] = shallowcopy(triangle)
	end

	triangles[1].v1 = 1
	triangles[1].v2 = 2
	triangles[1].v3 = 4

	triangles[2].v1 = 1
	triangles[2].v2 = 3
	triangles[2].v3 = 6

	triangles[3].v1 = 1
	triangles[3].v2 = 4
	triangles[3].v3 = 6

	triangles[4].v1 = 2
	triangles[4].v2 = 4
	triangles[4].v3 = 7

	triangles[5].v1 = 2
	triangles[5].v2 = 5
	triangles[5].v3 = 7

	triangles[6].v1 = 3
	triangles[6].v2 = 6
	triangles[6].v3 = 8

	triangles[7].v1 = 4
	triangles[7].v2 = 6
	triangles[7].v3 = 9

	triangles[8].v1 = 4
	triangles[8].v2 = 7
	triangles[8].v3 = 9

	triangles[9].v1 = 5
	triangles[9].v2 = 7
	triangles[9].v3 = 10

	triangles[10].v1 = 6
	triangles[10].v2 = 8
	triangles[10].v3 = 9

	triangles[11].v1 = 7
	triangles[11].v2 = 9
	triangles[11].v3 = 10
  end

  return coins, triangles, charts
end
