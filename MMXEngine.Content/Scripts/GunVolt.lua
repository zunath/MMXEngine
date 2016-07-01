function OnDamaged()

end

function OnDeath()

end

function OnHeartbeat()

end

function OnSpawn()

end

function OnTouch()
	local settingCustom = false;
	local setting = GetLocalNumber(this, "Setting") + 1;

	local color = Color.Black;
	if(setting > 5) then
		setting = 1;
	end
	SetLocalValue(this, "Setting", setting);

	if(setting == 1) then
		color = Color.Black;
	elseif(setting == 2) then
		color = Color.Red;
	elseif(setting == 3) then 
		color = Color.White;
	elseif(setting == 4) then
		settingCustom = true;
		SetColorPaletteCustom(this, 192, 192, 192, 255);
	else
		color = Color.Green;
	end

	if(not settingCustom) then
		SetColorPalette(this, color);
	end
end

