using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;

[assembly: ModInfo("Alloy Calculator",
  Authors = new[] { "Craluminum2413" })]

namespace AlloyCalculator
{
  public class AlloyCalculator : ModSystem
  {
    ICoreClientAPI capi;
    GuiDialog dialog;

    public override bool ShouldLoad(EnumAppSide forSide) => forSide == EnumAppSide.Client;

    public override void StartClientSide(ICoreClientAPI api)
    {
      base.StartClientSide(api);

      dialog = new GuiDialogAlloyCalculator(api);

      capi = api;
      capi.Input.RegisterHotKey("alloycalculator", Lang.Get("alloycalculator:Open 'Alloy Calculator'"), GlKeys.U, HotkeyType.GUIOrOtherControls);
      capi.Input.SetHotKeyHandler("alloycalculator", ToggleGui);
    }

    private bool ToggleGui(KeyCombination comb)
    {
      if (dialog.IsOpened()) dialog.TryClose();
      else dialog.TryOpen();

      return true;
    }
  }
}