namespace CCConverterUI
{
    internal static class Constants
    {
        public const string AppName = "CCConverter";

        public const string AppSettingsFileName = "ccconverter.cfg";

        public const string InvalidPaths = "Not all paths are valid.";

        public const string DefaultNewLineMarker = "// ### not translated!";

        public const string OkMessageFormat =
@"Done.
Click OK to show file in folder.

*** NOTE - Please read ***

" + NewLineMarkerInfoFormat;

        public const string NewLineMarkerInfoFormat =
@"In output file you'll find lines marked with ""{0}"".

Those are either:
A) Totally new lines that didn't exist in old file,
OR, which is more likely,
B) just slightly altered lines from old file.

Try find something similar in old localized file before translating it from scratch.";

        public const string ErrorMessageFormat =
@"Whoops! Something broke.
PLEASE press CTRL + C and send copied details to tool's author.

{0}

{1}";

        public const string ContactInfo =
@"This program was written by Igor ""Igoreso"" B.

You can contact me via one of the following.
(Press CTRL + C to copy all details to your clipboard.)

    Email (preferred)
    igoreso.spb@gmail.com

    Project on GitHub
    https://github.com/Igoreso/Source-engine-games-CCConverter

    Steam Community
    http://steamcommunity.com/id/igoreso/

    Black Mesa Community Forums
    http://forums.blackmesasource.com/index.php/User/6340-Igoreso/

    Black Mesa International
    http://bmtranslate.darkbb.com/u21contact

    Notabenoid
    http://notabenoid.org/users/151902
";

        public const string LicenseText =
@"
Proper license text is below, but in short you can share and modify this tool as long as you mention my name, my email address and link to this project on github - all of this can be found in About window. Thanks.


*** LICENSE ***

Copyright (c) 2015-2016, Igor Beresnev <igoreso.spb@gmail.com>

Permission to use, copy, modify, and/or distribute this software for any purpose with or without fee is hereby granted, provided that the above copyright notice and this permission notice appear in all copies.

THE SOFTWARE IS PROVIDED ""AS IS"" AND THE AUTHOR DISCLAIMS ALL WARRANTIES WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.

This software uses 3rd party library (http://dotnetzip.codeplex.com/) distributed under MS-Public license.


*** OTHER NOTES ***

Regarding DotNetZip - only FolderBrowserDialogEx is used, based on this:
http://dotnetzip.codeplex.com/SourceControl/changeset/view/29499#432677";
    }
}
