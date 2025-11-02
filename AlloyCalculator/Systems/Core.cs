using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;

namespace AlloyCalculator;

public class Core : ModSystem
{
    ICoreClientAPI _capi;
    GuiDialog _dialog;

    public override bool ShouldLoad(EnumAppSide forSide) => forSide == EnumAppSide.Client;

    public override void StartClientSide(ICoreClientAPI api)
    {
        _capi = api;

        api.Input.RegisterHotKey("alloycalculator", Lang.Get("alloycalculator:Open 'Alloy Calculator'"), GlKeys.U, HotkeyType.GUIOrOtherControls);
        api.Input.SetHotKeyHandler("alloycalculator", ToggleGui);
    }

    private bool ToggleGui(KeyCombination keyCombination)
    {
        if (_dialog is null) _dialog = new GuiDialogAlloyCalculator(_capi);
        if (!_dialog.IsOpened()) return _dialog.TryOpen();
        if (!_dialog.TryClose()) return true;
        _dialog.Dispose();
        _dialog = null;
        return true;
    }
}