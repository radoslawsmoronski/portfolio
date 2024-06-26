﻿namespace portfolio.Models.Skill
{
    public class SkillView
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; }

        public SkillView(Skill skill, string langCode)
        {
            ImageUrl = skill.ImageUrl;
            Name = langCode == "pl" ? skill.NamePL : skill.NameENG;
        }
    }
}
