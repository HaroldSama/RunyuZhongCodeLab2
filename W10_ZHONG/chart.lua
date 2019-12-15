chart = {
	name,
	levelBasedOn,
	stars,
	lines,
	originX,
	originY,
	sizeX,
	sizeY,
	scale = 20,
	finished = false
}

charts = {}

--[[ 
   Level1:

   1.......7
   .........
   2...3....
   .........
   4...5...6


   ]]

function makeCharts()

	lyra = shallowcopy(chart)
	lyra.name = "LYRA"
	lyra.levelBasedOn = 1
	lyra.stars = {false, true, true, true, true, false, true}
	lyra.lines ={{2, 3}, {3, 5}, {4, 5}, {2, 4}, {3, 7}}
	lyra.originX = 600
	lyra.originY = 350
	lyra.sizeX = 4
	lyra.sizeY = 4
	charts[1] = lyra

    crux = shallowcopy(chart)
    crux.name = "CRUX"
    crux.levelBasedOn = 1
    crux.stars = {true, false, true, true, false, true, true}
    crux.lines = {{1, 3}, {3, 4}, {3, 6}, {3, 7}}
    crux.originX = 600
    crux.originY = 100
    crux.sizeX = 4
    crux.sizeY = 4
    charts[2] = crux

    taurus = shallowcopy(chart)
    taurus.name = "TAURUS"
    taurus.levelBasedOn = 2
    taurus.stars = {true, true, true, true, true, true, true}
    taurus.lines = {{1, 7}, {1, 3}, {3, 5}, {3, 4}, {2, 4}, {4, 6}}
    taurus.originX = 600
    taurus.originY = 100
    taurus.sizeX = 4
    taurus.sizeY = 4
    charts[3] = taurus

    lybra = shallowcopy(chart)
    lybra.name = "LYBRA"
    lybra.levelBasedOn = 2
    lybra.stars = {true, true, false, false, true, true, true}
    lybra.lines = {{1, 7}, {1, 5}, {5, 7}, {1, 2}, {5, 6}}
    lybra.originX = 600
    lybra.originY = 350
    lybra.sizeX = 4
    lybra.sizeY = 4
    charts[4] = lybra

    leo = shallowcopy(chart)
    leo.name = "LEO"
    leo.levelBasedOn = 3
    leo.stars = {true, true, true, false, false, true, true, true}
    leo.lines = {{1, 3}, {2, 3}, {2, 6}, {3, 7}, {6, 7}, {6, 8}, {7, 8}}
    leo.originX = 500
    leo.originY = 100
    leo.sizeX = 2
    leo.sizeY = 3
    leo.scale = 40
    charts[5] = leo

    aries = shallowcopy(chart)
    aries.name = "ARIES"
    aries.levelBasedOn = 3
    aries.stars = {true, false, false, true, false, false, true, true}
    aries.lines = {{1, 4}, {4, 7}, {7, 8}}
    aries.originX = 650
    aries.originY = 100
    aries.sizeX = 2
    aries.sizeY = 3
    aries.scale = 40
    charts[6] = aries

    scorpius = shallowcopy(chart)
    scorpius.name = "SCORPIUS"
    scorpius.levelBasedOn = 3
    scorpius.stars = {true, true, true, true, true, true, true, true}
    scorpius.lines = {{2, 3}, {2, 5}, {2, 6}, {2, 1}, {1, 4}, {4, 7}, {7, 8}}
    scorpius.originX = 500
    scorpius.originY = 350
    scorpius.sizeX = 2
    scorpius.sizeY = 3
    scorpius.scale = 40
    charts[7] = scorpius

    cancer = shallowcopy(chart)
    cancer.name = "CANCER"
    cancer.levelBasedOn = 3
    cancer.stars = {true, true, true, false, false, false, true, true}
    cancer.lines = {{1, 3}, {2, 3}, {3, 7}, {7, 8}}
    cancer.originX = 650
    cancer.originY = 350
    cancer.sizeX = 2
    cancer.sizeY = 3
    cancer.scale = 40
    charts[8] = cancer

    gemini = shallowcopy(chart)
    gemini.name = "GEMINI"
    gemini.levelBasedOn = 4
    gemini.stars = {true, true, false, false, false, true, true, true, true, true}
    gemini.lines = {{1, 6}, {6, 8}, {6, 9}, {2, 7}, {7, 9}, {7, 10}}
    gemini.originX = 520
    gemini.originY = 100
    gemini.sizeX = 4
    gemini.sizeY = 3
    gemini.scale = 20
    charts[9] = gemini

    sagittarius = shallowcopy(charts)
    sagittarius.name = "SAGITTARIUS"
    sagittarius.levelBasedOn = 4
    sagittarius.stars = {false, true, true, false, true, true, true, true, true, true}
    sagittarius.lines = {{3, 6}, {6, 8}, {6, 9}, {7, 9}, {7, 10}, {5, 7}, {2, 7}}
    sagittarius.originX = 520
    sagittarius.originY = 250
    sagittarius.sizeX = 4
    sagittarius.sizeY = 3
    sagittarius.scale = 20
    charts[10] = sagittarius

    virgo = shallowcopy(charts)
    virgo.name = "VIRGO"
    virgo.levelBasedOn = 4
    virgo.stars = {true, true, false, true, false, false, false, true, true, true}
    virgo.lines = {{1, 2}, {1, 4}, {2, 4}, {4, 9}, {8, 9}, {9, 10}}
    virgo.originX = 520
    virgo.originY = 400
    virgo.sizeX = 4
    virgo.sizeY = 3
    virgo.scale = 20
    charts[11] = virgo

    capricorn = shallowcopy(charts)
    capricorn.name = "CAPRICORN"
    capricorn.levelBasedOn = 4
    capricorn.stars = {false, true, false, true, true, true, false, true, true, true}
    capricorn.lines = {{2, 4}, {2, 5}, {4, 6}, {6, 8}, {8, 9}, {9, 10}, {5, 10}}
    capricorn.originX = 670
    capricorn.originY = 100
    capricorn.sizeX = 4
    capricorn.sizeY = 3
    capricorn.scale = 20
    charts[12] = capricorn

    aquarius = shallowcopy(charts)
    aquarius.name = "AQUARIUS"
    aquarius.levelBasedOn = 4
    aquarius.stars = {true, true, true, true, true, true, true, true, true, true}
    aquarius.lines = {{1, 3}, {1, 4}, {3, 6}, {4, 6}, {6, 8}, {6, 9}, {4, 7}, {5, 7}, {2, 5}, {5, 10}}
    aquarius.originX = 670
    aquarius.originY = 250
    aquarius.sizeX = 4
    aquarius.sizeY = 3
    aquarius.scale = 20
    charts[13] = aquarius

    pisces = shallowcopy(charts)
    pisces.name = "PISCES"
    pisces.levelBasedOn = 4
    pisces.stars = {true, true, false, true, true, false, true, false, true, false}
    pisces.lines = {{1, 4}, {4, 9}, {9, 7}, {7, 2}, {7, 5}, {2, 5}}
    pisces.originX = 670
    pisces.originY = 400
    pisces.sizeX = 4
    pisces.sizeY = 3
    pisces.scale = 20
    charts[14] = pisces

end