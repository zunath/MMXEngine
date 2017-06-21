-- Fires once every second on this object
function OnHeartbeat()

end

-- Fires once when the level finishes loading
function OnLoad()

	Audio:PauseMusic();

	local enemy = Entity:CreateEnemy("GunVolt", 200, -200, DirectionType.Left);
	local item = Entity:CreateItem("OneUp", 8, -100);

end