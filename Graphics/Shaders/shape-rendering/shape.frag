#version 460 core
out vec4 FragColor;

in vec4 shapeColor;

uniform sampler2D sprite_sheet;

void main() {
    FragColor = shapeColor;
}