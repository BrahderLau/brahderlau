

import FlashOnIcon from '@material-ui/icons/FlashOn';
import FormatBoldIcon from '@material-ui/icons/FormatBold';
import FormatItalicIcon from '@material-ui/icons/FormatItalic';
import StrikethroughSIcon from '@material-ui/icons/StrikethroughS';
import CodeIcon from '@material-ui/icons/Code';
import LinkIcon from '@material-ui/icons/Link';
import FormatListNumberedIcon from '@material-ui/icons/FormatListNumbered';
import FormatListBulletedIcon from '@material-ui/icons/FormatListBulleted';
import MoreHorizIcon from '@material-ui/icons/MoreHoriz';
import TextFormatIcon from '@material-ui/icons/TextFormat';
import InsertEmoticonIcon from '@material-ui/icons/InsertEmoticon';
import AttachFileIcon from '@material-ui/icons/AttachFile';

export const shortcutButton = {
    icon: <FlashOnIcon />,
    text: "Shortcuts"
}

export const messageLeftBarButtons = [
    {
        icon: <FormatBoldIcon />,
        text: "Bold"
    },
    {
        icon: <FormatItalicIcon />,
        text: "Italic"
    },
    {
        icon: <StrikethroughSIcon />,
        text: "Strikethrough"
    },
    {
        icon: <CodeIcon />,
        text: "Inline"
    },
    {
        icon: <LinkIcon />,
        text: "Link"
    },
    {
        icon: <FormatListNumberedIcon />,
        text: "Ordered list"
    },
    {
        icon: <FormatListBulletedIcon />,
        text: "Bulleted list"
    },
]

export const messageRightBarButtons = [
    {
        icon: <MoreHorizIcon />,
        text: "More tools"
    },
    {
        icon: <TextFormatIcon />,
        text: "Display/Hide formatting tools"
    },
    {
        icon: <InsertEmoticonIcon />,
        text: "Insert emoji(s)"
    },
    {
        icon: <AttachFileIcon />,
        text: "Attach file"
    }
]