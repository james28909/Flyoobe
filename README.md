# Flyby11 (FlybyScript) Windows 11 for All – No Specs, No Problem!
Flyby11 is a simple patcher that removes the annoying restrictions preventing you from installing Windows 11 (24H2) on unsupported hardware. Got an old PC? No TPM, Secure Boot, or your processor isn't supported? Flyby11 lets you install Windows 11 24H2 anyway.

No complicated steps. 
**Just run the tool (see ["Releases"](https://github.com/builtbybel/Flyby11/releases/latest) in the right side of the page, you may need to unpack a zip file), and you'll be running Windows 11 on your outdated machine in no time.**
Think of it as sneaking through the back door without anyone noticing.

# Technical Overview
Flyby11 leverages a feature of the Windows 11 setup process that uses the Windows Server variant of the installation. This variant, unlike the regular Windows 11 setup, skips most hardware compatibility checks, allowing it to run on unsupported systems. Here’s a more technical breakdown of the process:

Windows Server Setup: The tool uses the Windows Server variant of the setup, which avoids the usual checks for things like TPM, Secure Boot, and specific processor requirements.
Install Regular Windows 11: Even though the setup runs in server mode, it installs the normal Windows 11 version (not the server version).
Manual ISO Preparation: Flyby11 automates the download and mounting of the ISO, so you don’t need to manually tweak anything. You can get the ISO from official sources or the tool will handle it using the [Fido script](https://github.com/pbatard/Fido)
This method is the same approach described in the official Windows documentation for upgrading unsupported systems, as [detailed in this article](https://support.microsoft.com/en-us/windows/ways-to-install-windows-11-e0edbbfb-cfc5-4011-868b-2ce77ac7c70e)

# Why Flyby11 Makes Sense
- Upgrade Freedom – Dont ditch a perfectly fine PC just because Microsoft says so
- Eco-Friendly – Less forced upgrades = less e-waste
- Save Money – No need to spend on new hardware when your current setup still works

# Disclaimer
_Flyby11 offers all the currently working methods to bypass the restrictions for installing Windows 11 24H2 on unsupported hardware. The internet is full of guides showing how to get around the TPM, Secure Boot, and processor requirements, but Flyby11 does all that automatically for you._

**Technical Note:** The POPCNT requirement cannot be bypassed; it is essential for running Windows 11 (24H2), as the operating system requires this feature to be supported by the CPU. POPCNT has been included in CPUs since around 2010. However, the patch is expected to work for most users with compatible hardware.Please do not blame me; I am working within the constraints of what is technically possible.
