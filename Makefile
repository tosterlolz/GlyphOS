ISO=./bin/cosmos/Debug/net6.0/GlyphOS.iso
FSIMG=fs.img

all: build run

build:
	dotnet build

run: 
	qemu-system-i386 -cdrom $(ISO) -hda $(FSIMG) -boot d -m 256

clean:
	dotnet clean
	rm -f $(FSIMG)

.PHONY: all build iso run clean