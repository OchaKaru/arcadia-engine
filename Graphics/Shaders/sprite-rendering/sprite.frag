#version 460 core
out vec4 FragColor;

in vec4 spriteColor;
in vec2 texCoords;

uniform sampler2D sprite_sheet;

void main() {
    FragColor = spriteColor.w * texture(sprite_sheet, texCoords) * vec4(spriteColor.xyz, 1.0);
}