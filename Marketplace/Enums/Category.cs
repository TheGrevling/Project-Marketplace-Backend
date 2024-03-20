using System.ComponentModel;

namespace Marketplace.Enums
{
    public enum Category
    {
        [Description("Boardgame")]
        Boardgame,
        [Description("Cardgame")]
        Cardgame,
        [Description("Roleplay")]
        Roleplay,
        [Description("Puzzlegame")]
        Puzzlegame
    }
}
