function OnDamaged()

end

function OnDeath()

end

function OnHeartbeat()
	print("firing gun volt heartbeat");
end

function OnSpawn()

end

function OnTouch()

	local x = GetPlayer();
	local type = GetCharacterType(x);
	local name = GetName(this);
	print(name);
end

