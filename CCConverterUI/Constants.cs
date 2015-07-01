namespace CCConverterUI
{
    internal static class Constants
    {
        public const string OkMessage =
@"Done.
Click OK to show file in folder.

*** NOTE - Please read ***

In output file you'll find lines marked with *** - those are either totally new lines (that didn't exist in old file) OR (!) just slightly altered lines from old file.

Try find something similar in old localized file before translating it from scratch.";

        public const string ErrorMessageFormat =
@"Whoops! Something broke.
PLEASE press CTRL + C and send copied details to tool's author.

{0}

{1}";

        public const string ContactInfo =
@"This program was written by Igor ""Igoreso"" B.

Proper license text is below, but in short - you can share and modify this tool as long as you mention email address and link to project on github. Thanks.

You can contact me via one of the following.
(Press CTRL + C to copy all details to your clipboard.)

    Email (preferred)
    igoreso.spb@gmail.com

    Steam Community
    http://steamcommunity.com/id/igoreso/

    Black Mesa Community Forums
    http://forums.blackmesasource.com/index.php/User/6340-Igoreso/

    Black Mesa International
    http://bmtranslate.darkbb.com/u21contact

    Notabenoid
    http://notabenoid.org/users/151902


*** LICENSE ***

Copyright (c) 2015, Igor Beresnev <igoreso.spb@gmail.com>

Permission to use, copy, modify, and/or distribute this software for any purpose with or without fee is hereby granted, provided that the above copyright notice and this permission notice appear in all copies.

THE SOFTWARE IS PROVIDED ""AS IS"" AND THE AUTHOR DISCLAIMS ALL WARRANTIES WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.

This software uses 3rd party library (http://dotnetzip.codeplex.com/) distributed under MS-Public license.";
    }
}
