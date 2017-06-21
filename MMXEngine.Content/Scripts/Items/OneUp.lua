function OnTouch()
	local lives = Player:GetPlayerNumberOfLives();

	if lives < 9 then
		Audio:PlaySFX("OneUp2");
		lives = lives + 1;
		Player:SetPlayerNumberOfLives(lives);
	end

	Entity:DestroyObject(self);
end