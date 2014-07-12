Decompiled Stars! Utilities
=====

Here are the decompiled sources to several Stars! utilities.  These are provided for reference in building out a Stars! API.

## Utilities

### StarsHostCreator / StarsHostCreator_StarsHostEditor
Found at: http://wiki.starsautohost.org/files/StarsHostCreatorv010.zip

Stars! Host Creator allows you to create a .hst file from your m, h and r files for testbedding scenarios.

**Note:** The StarsHostEditor DLL included in StarsHostCreator (decompiled in StarsHostCreator_StarsHostEditor) is the latest I could find and probably the best reference for the code.

### StarsHostEditor
Found at: http://wiki.starsautohost.org/files/starshosteditor0.3.zip

Stars Host Editor is an ActiveX object model for editing planets in the *.hst files via vbs scripts(or other means).

**Note:** This is version 0.3 of StarsHostEditor.  Newer code may be found in the StarsHostEditor_StarsHostCreator directory.

### StarsPlayerEditor
Found at: http://wiki.starsautohost.org/files/starsplayereditor.zip

Stars Player Editor is an ActiveX object model for editing planets in the *.m files via vbs scripts.

**Note:** This uses code from StarsHostEditor 0.2 which is know to have a bug in the Decryptor class.

### StarsSumpremacyHost / StarsSupremacyHostDLL
Found at: http://wiki.starsautohost.org/files/StarsSupremacyHost.zip

Stars! Supremacy Host is an x file checker that detects some bugs/cheats. Currently checks for 22 or more superlatinum in a slot, prevents use of the 10th space dock for all races and prevents editing starbase design if there are partially completed ones in planet queue. The DLL has been written to allow or disallow each check on user by user basis basis but the test exe for it does not allow you to configure them.
