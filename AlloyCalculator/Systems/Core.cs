using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;

namespace AlloyCalculator;

public class Core : ModSystem
{
    public override bool ShouldLoad(EnumAppSide forSide) => forSide == EnumAppSide.Client;

    public override void StartClientSide(ICoreClientAPI api)
    {
        api.Input.RegisterHotKey("alloycalculator", Lang.Get("alloycalculator:Open 'Alloy Calculator'"), GlKeys.U, HotkeyType.GUIOrOtherControls);
        api.Gui.RegisterDialog(new GuiDialogAlloyCalculator(api));
    }
}