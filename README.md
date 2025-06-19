# Bitmask Mapper

A Windows Forms application for visualizing and converting between binary, hexadecimal, and decimal representations of bitmasks.


## Features

- Visualize bitmasks with individual bit toggles
- Convert between binary, hex, and decimal representations
- Adjustable bit length (8-64 bits)
- Clear all bits with one click
- Real-time updates across all formats
- Intuitive bit numbering (MSB 0 notation)

## Usage

1. Select desired bit count (8-64) from the numeric selector
2. Edit bits directly by clicking on individual bit boxes (0/1)
3. Or enter values in any of the three formats:
   - Binary (e.g., `10101010`)
   - Hex (e.g., `0xAA`)
   - Decimal (e.g., `170`)
4. Use "Clear Bits" button to reset all bits to 0

## Keyboard Shortcuts

- `Ctrl+Backspace` - Delete previous word in hex/decimal fields
- `0`/`1` - Quick bit toggling when focused on bit boxes

## Installation

1. Clone this repository
2. Open in Visual Studio (2019 or later recommended)
3. Build and run the project

## Requirements

- .NET Framework 4.7.2 or later
- Windows OS

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
