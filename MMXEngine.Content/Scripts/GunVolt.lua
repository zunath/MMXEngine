function OnDamaged()

end

function OnDeath()

end

function OnHeartbeat()

end

function OnSpawn()

end

function OnTouch()

	local x = GetPlayer();
	local type = GetCharacterType(x);
	local name = GetName(this);
	print(name);
end

