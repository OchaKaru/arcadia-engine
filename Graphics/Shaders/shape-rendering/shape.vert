#version 460 core
layout(location = 0) in vec2 position;

out vec4 shapeColor;

struct shapeInfo {
    mat4 model;
    vec4 color;
};
layout(binding = 2) buffer shape_info_buffer {
	shapeInfo shape;
};

uniform mat4 projection;

void main() {
	shapeColor = shape.color;

	gl_Position = projection * shape.model * vec4(position.xy, 0.0, 1.0);
}