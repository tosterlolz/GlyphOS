ISO=./bin/cosmos/Debug/net6.0/GlyphOS.iso
FSIMG=fs.img

all: build run

fs: 
	dd if=/dev/zero of=fs.img bs=1M count=64
	mkfs.fat -F 32 fs.img

build:
	dotnet build

run: 
	qemu-system-i386 -cdrom $(ISO) -hda $(FSIMG) -boot d -m 256

clean:
	dotnet clean
	rm -f $(FSIMG)

.PHONY: all build iso run clean