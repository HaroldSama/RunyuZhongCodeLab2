function makeLevel(level)

  local coins = {}
  local triangles = {}


  --------------------------------------------------------------lv1
  if level == 1 then
  	for i = 1, 6 do
      coins[i] = shallowcopy(coin)
	end

    coins[1].x = 200
    coins[1].y = 100

    coins[2].x = 200
    coins[2].y = 300

	coins[3].x = 400
	coins[3].y = 300

	coins[4].x = 200
	coins[4].y = 500

	coins[5].x = 400
	coins[5].y = 500

	coins[6].x = 600
	coins[6].y = 500

	for i = 1, 4 do
	  triangles[i] = shallowcopy(triangle)
	end

	triangles[1].v1 = 1
	triangles[1].v2 = 2
	triangles[1].v3 = 3

	triangles[2].v1 = 2
	triangles[2].v2 = 3
	triangles[2].v3 = 5

	triangles[3].v1 = 2
	triangles[3].v2 = 4
	triangles[3].v3 = 5

	triangles[4].v1 = 3
	triangles[4].v2 = 5
	triangles[4].v3 = 6
  end


  -----------------------------------------------------------------lv2
  if level == 2 then
  	for i = 1, 7 do
      coins[i] = shallowcopy(coin)
	end

    coins[1].x = 200
    coins[1].y = 150

    coins[2].x = 600
    coins[2].y = 150

	coins[3].x = 300
	coins[3].y = 300

	coins[4].x = 500
	coins[4].y = 300

	coins[5].x = 200
	coins[5].y = 450

	coins[6].x = 600
	coins[6].y = 450

	coins[7].x = 100
	coins[7].y = 300

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
  	for i = 1, 8 do
      coins[i] = shallowcopy(coin)
	end

    coins[1].x = 500
    coins[1].y = 100

    coins[2].x = 700
    coins[2].y = 300

	coins[3].x = 300
	coins[3].y = 100

	coins[4].x = 500
	coins[4].y = 300

	coins[5].x = 300
	coins[5].y = 300

	coins[6].x = 500
	coins[6].y = 500

	coins[7].x = 100
	coins[7].y = 300

	coins[8].x = 300
	coins[8].y = 500

	for i = 1, 8 do
	  triangles[i] = shallowcopy(triangle)
	end

	triangles[1].v1 = 3
	triangles[1].v2 = 5
	triangles[1].v3 = 7

	triangles[2].v1 = 1
	triangles[2].v2 = 3
	triangles[2].v3 = 5

	triangles[3].v1 = 1
	triangles[3].v2 = 4
	triangles[3].v3 = 5

	triangles[4].v1 = 1
	triangles[4].v2 = 2
	triangles[4].v3 = 4

	triangles[5].v1 = 5
	triangles[5].v2 = 7
	triangles[5].v3 = 8

	triangles[6].v1 = 4
	triangles[6].v2 = 5
	triangles[6].v3 = 8

	triangles[7].v1 = 4
	triangles[7].v2 = 6
	triangles[7].v3 = 8

	triangles[8].v1 = 2
	triangles[8].v2 = 4
	triangles[8].v3 = 6
  end


  --------------------------------------------------------------------------lv4
  if level == 4 then
  	for i = 1, 10 do
      coins[i] = shallowcopy(coin)
	end

    coins[1].x = 300
    coins[1].y = 150

    coins[2].x = 500
    coins[2].y = 150

	coins[3].x = 200
	coins[3].y = 250

	coins[4].x = 400
	coins[4].y = 250

	coins[5].x = 600
	coins[5].y = 250

	coins[6].x = 300
	coins[6].y = 350

	coins[7].x = 500
	coins[7].y = 350

	coins[8].x = 200
	coins[8].y = 450

	coins[9].x = 400
	coins[9].y = 450

	coins[10].x = 600
	coins[10].y = 450

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


  return coins, triangles
end
