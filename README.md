# SPT.NoInsurance

Client mod for **SPT 4.1.6** that skips the insurance screen when you queue for a raid as a PMC.

Port of [vibrantrida/no-insurance](https://gitlab.com/vibrantrida/no-insurance) (0BSD) to SPT 4.x.

## Install

Drop `NoInsurance.dll` into `<SPT>/BepInEx/plugins/`.

## What changed in the port

- `MainMenuControllerClass` is now `EFT.MainMenuShowOperation` in SPT 4.x.
- The original prefixed `method_80` and forced `RaidSettings.RaidMode = Local` to make the game skip insurance.
  The port instead prefixes `MainMenuShowOperation.method_51` (the method that shows the insurance screen)
  and jumps straight to `method_52` (the ready/accept step). `RaidMode` is left untouched, so group/Fika logic is unaffected.
- Trimmed references, removed the `.vs` folder, and made the SPT install path configurable.

## Build

Requires the .NET SDK and an SPT 4.1.6 install.

```sh
dotnet build -c Release -p:SPTPath="C:\SPT"
# add -p:InstallToSPT=true to copy the DLL into BepInEx/plugins
```

If the repo sits in `<SPT>/Development/SPT.NoInsurance`, `SPTPath` can be omitted.

Note: `method_51` / `method_52` are obfuscated names. They will likely change with the next EFT/SPT version.

## License

[0BSD](LICENSE.md), same as the original.
