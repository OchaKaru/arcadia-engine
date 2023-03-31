#version 460 core
layout(location = 0) in int quadID;
layout(location = 1) in vec2 position;

out vec4 spriteColor;
out vec2 texCoords;

struct spriteInfo {
	mat4 model;
	vec4 color;

	vec2 sheetCoords;
	vec2 sheetDim;
};
layout(std430, binding = 2) buffer sprite_info_buffer {
	spriteInfo sprites[];
};

uniform mat4 projection;

void main() {
	spriteInfo sprite = sprites[quadID];

	spriteColor = sprite.color;
	texCoords = vec2(
		(sprite.sheetCoords.x + position.x) / sprite.sheetDim.x,
		(sprite.sheetCoords.y + position.y) / sprite.sheetDim.y
	);

	gl_Position = projection * sprite.model * vec4(position.xy, 0.0, 1.0);
}