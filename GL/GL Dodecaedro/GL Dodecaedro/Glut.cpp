#include <windows.h>  // for MS Windows
#include <GL/glut.h>  // GLUT, include glu.h and gl.h
#include <math.h>
/* Global variables */
char title[] = "3D Shapes";
float cameraRadius = 12.0f;
float cameraAngle = 0.0f;
float cameraHeight = 1.0f;
float centerPosition[3] = { 0.0f, 0.0f, 0.0f };
/* Initialize OpenGL Graphics */
void initGL() {
    glClearColor(0.0f, 0.0f, 0.0f, 1.0f); // Set background color to black and opaque
    glClearDepth(1.0f);                   // Set background depth to farthest
    glEnable(GL_DEPTH_TEST);   // Enable depth testing for z-culling
    glDepthFunc(GL_LEQUAL);    // Set the type of depth-test
    glShadeModel(GL_SMOOTH);   // Enable smooth shading
    glHint(GL_PERSPECTIVE_CORRECTION_HINT, GL_NICEST);  // Nice perspective corrections
}

/* Handler for window-repaint event. Called back when the window first appears and
   whenever the window needs to be re-painted. */
void display() {
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT); // Clear color and depth buffers
    glMatrixMode(GL_MODELVIEW);     // To operate on model-view matrix

    // Render a color-cube consisting of 6 quads with different colors
    glLoadIdentity();                 // Reset the model-view matrix
    glTranslatef(0.0f, -1.5f, -10.0f);  // Move right and into the screen

    float cameraX = centerPosition[0] + cameraRadius * sin(cameraAngle);
    float cameraZ = centerPosition[2] + cameraRadius * cos(cameraAngle);

    gluLookAt(cameraX, cameraHeight, cameraZ, centerPosition[0], centerPosition[1], centerPosition[2], 0.0f, 1.0f, 0.0f);

    //Pentagono 0 (Base Izq)
    glBegin(GL_POLYGON);
    glColor3f(1.0f, 0.0f, 0.0f); // Color rojo
    glVertex3f(-1.0f, 0.0f, 0.0f); // Vértice inf izq -A
    glColor3f(0.0f, 1.0f, 0.0f); // Color verde
    glVertex3f(-1.62f, 0.0f, 1.9f); // Vértice sup izq -E
    glColor3f(0.0f, 0.0f, 1.0f); // Color azul
    glVertex3f(0.0f, 0.0f, 3.08f); // Vértice sup -D
    glColor3f(0.0f, 1.0f, 1.0f); // Color cian
    glVertex3f(0.0f, 0.0f, 0.0f); // Vértice inf der -K2
    glEnd();

    //Pentagono 0.1 (Base Der)
    glBegin(GL_POLYGON);
    glColor3f(1.0f, 0.0f, 0.0f); // Color rojo
    glVertex3f(0.0f, 0.0f, 0.0f); // Vértice inf izq -K2
    glColor3f(0.0f, 1.0f, 0.0f); // Color verde
    glVertex3f(0.0f, 0.0f, 3.08f); // Vértice sup -D
    glColor3f(0.0f, 0.0f, 1.0f); // Color azul
    glVertex3f(1.62f, 0.0f, 1.9f); // Vértice sup der -C
    glColor3f(0.0f, 1.0f, 1.0f); // Color cian
    glVertex3f(1.0f, 0.0f, 0.0f); // Vértice inf der -B
    glEnd();

    //Pentagono 1.0 (Lado Izq) Color negro y a la derecha
    glBegin(GL_POLYGON);
    glColor3f(1.0f, 0.0f, 0.0f); // Color rojo
    glVertex3f(-2.62f, 1.7f, 2.23f); // Vértice inf izq -C1
    glColor3f(0.0f, 1.0f, 0.0f); // Color verde
    glVertex3f(-2.62f, 2.75f, 0.53f); // Vértice sup izq -D1
    glColor3f(0.0f, 0.0f, 1.0f); // Color azul
    glVertex3f(-2.12f, 2.23f, -0.16f); // Vértice sup der -P2
    glColor3f(0.0f, 1.0f, 1.0f); // Color cian
    glVertex3f(-1.62f, 0.0f, 1.9f); // Vértice inf der -A1
    glEnd();

    //Pentagono 1.1 (Lado Der)
    glBegin(GL_POLYGON);
    glColor3f(1.0f, 0.0f, 0.0f); // Color rojo
    glVertex3f(-1.62f, 0.0f, 1.9f); // Vértice inf izq -A1
    glColor3f(0.0f, 1.0f, 0.0f); // Color verde
    glVertex3f(-2.12f, 2.23f, -0.16f); // Vértice sup izq -P2
    glColor3f(0.0f, 0.0f, 1.0f); // Color azul
    glVertex3f(-1.62f, 1.7f, -0.85f); // Vértice sup der -B1
    glColor3f(0.0f, 1.0f, 1.0f); // Color cian
    glVertex3f(-1.0f, 0.0f, -0.0f); // Vértice sup izq -U
    glEnd();

    //Pentagono 2.0 (Lado Izq)
    glBegin(GL_POLYGON);
    glColor3f(1.0f, 0.0f, 0.0f); // Color rojo
    glVertex3f(-1.0f, 0.0f, -0.0f); // Vértice inf izq -U
    glColor3f(0.0f, 1.0f, 0.0f); // Color verde
    glVertex3f(-1.62f, 1.7f, -0.85f); // Vértice sup izq -B1
    glColor3f(0.0f, 0.0f, 1.0f); // Color azul
    glVertex3f(0.0f, 2.75f, -1.38f); // Vértice sup der -M1
    glColor3f(0.0f, 1.0f, 1.0f); // Color cian
    glVertex3f(0.0f, 0.0f, 0.0f); // Vértice inf der -K2
    glEnd();

    //Pentagono 2.1 (Lado Der)
    glBegin(GL_POLYGON);
    glColor3f(1.0f, 0.0f, 0.0f); // Color rojo
    glVertex3f(0.0f, 0.0f, 0.0f); // Vértice inf izq -K2
    glColor3f(0.0f, 1.0f, 0.0f); // Color verde
    glVertex3f(0.0f, 2.75f, -1.38f); // Vértice sup izq -M1
    glColor3f(0.0f, 0.0f, 1.0f); // Color azul
    glVertex3f(1.62f, 1.7f, -0.85f); // Vértice sup der -T1
    glColor3f(0.0f, 1.0f, 1.0f); // Color cian
    glVertex3f(1.0f, 0.0f, 0.0f); // Vértice inf der -V
    glEnd();

    //Pentagono 3.0 (Lado Izq)
    glBegin(GL_POLYGON);
    glColor3f(1.0f, 0.0f, 0.0f); // Color rojo
    glVertex3f(1.0f, 0.0f, 0.0f); // Vértice inf der -V
    glColor3f(0.0f, 1.0f, 0.0f); // Color verde
    glVertex3f(1.62f, 1.7f, -0.85f); // Vértice sup der -T1
    glColor3f(0.0f, 0.0f, 1.0f); // Color azul
    glVertex3f(2.12f, 2.23f, -0.16f); // Vértice sup der -M2
    glColor3f(0.0f, 1.0f, 1.0f); // Color cian
    glVertex3f(1.69f, 0.0f, 1.9f); // Vértice inf der -C
    glEnd();

    //Pentagono 3.1 (Lado Der)
    glBegin(GL_POLYGON);
    glColor3f(1.0f, 0.0f, 0.0f); // Color rojo
    glVertex3f(1.69f, 0.0f, 1.9f); // Vértice inf izq -C
    glColor3f(0.0f, 1.0f, 0.0f); // Color verde
    glVertex3f(2.12f, 2.23f, -0.16f); // Vértice sup izq -M2
    glColor3f(0.0f, 0.0f, 1.0f); // Color azul
    glVertex3f(2.62f, 2.75f, 0.53f); // Vértice sup der -U1
    glColor3f(0.0f, 1.0f, 1.0f); // Color cian
    glVertex3f(2.62f, 1.7f, 2.23f); // Vértice inf der -V1
    glEnd();

    //Pentagono 4.0 (Lado Izq)
    glBegin(GL_POLYGON);
    glColor3f(1.0f, 0.0f, 0.0f); // Color rojo
    glVertex3f(1.69f, 0.0f, 1.9f); // Vértice inf izq -C
    glColor3f(0.0f, 1.0f, 0.0f); // Color verde
    glVertex3f(2.62f, 1.7f, 2.23f); // Vértice sup izq -V1
    glColor3f(0.0f, 0.0f, 1.0f); // Color azul
    glVertex3f(2.12f, 2.23f, 2.92f); // Vértice sup der -O2
    glColor3f(0.0f, 1.0f, 1.0f); // Color cian
    glVertex3f(0.0f, 0.0f, 3.08f); // Vértice inf der -Z
    glEnd();
    //Pentagono 4.1 (Lado Der)
    glBegin(GL_POLYGON);
    glColor3f(1.0f, 0.0f, 0.0f); // Color rojo
    glVertex3f(2.12f, 2.23f, 2.92f); // Vértice inf izq -O2
    glColor3f(0.0f, 1.0f, 0.0f); // Color verde
    glVertex3f(1.62f, 2.75f, 3.6f); // Vértice sup izq -C2
    glColor3f(0.0f, 0.0f, 1.0f); // Color azul
    glVertex3f(0.0f, 1.7f, 4.13f); // Vértice sup der -D2
    glColor3f(0.0f, 1.0f, 1.0f); // Color cian
    glVertex3f(0.0f, 0.0f, 3.08f); // Vértice inf der -Z
    glEnd();

    //Pentagono 5.0 (Lado Izq)
    glBegin(GL_POLYGON);
    glColor3f(1.0f, 0.0f, 0.0f); // Color rojo
    glVertex3f(0.0f, 0.0f, 3.08f); // Vértice inf izq -Z
    glColor3f(0.0f, 1.0f, 0.0f); // Color verde
    glVertex3f(0.0f, 1.7f, 4.13f); // Vértice sup izq -D2
    glColor3f(0.0f, 0.0f, 1.0f); // Color azul
    glVertex3f(-1.62f, 2.75f, 3.6f); // Vértice sup der -E2
    glColor3f(0.0f, 1.0f, 1.0f); // Color cian
    glVertex3f(-2.12f, 2.23f, 2.92f); // Vértice inf der -N2
    glEnd();
    //Pentagono 5.1 (Lado Der)
    glBegin(GL_POLYGON);
    glColor3f(1.0f, 0.0f, 0.0f); // Color rojo
    glVertex3f(0.0f, 0.0f, 3.08f); // Vértice inf izq -Z
    glColor3f(0.0f, 1.0f, 0.0f); // Color verde
    glVertex3f(-2.12f, 2.23f, 2.92f); // Vértice sup izq -N2
    glColor3f(0.0f, 0.0f, 1.0f); // Color azul
    glVertex3f(-2.62f, 1.7f, 2.23f); // Vértice sup der -J2
    glColor3f(0.0f, 1.0f, 1.0f); // Color cian
    glVertex3f(-1.62f, 0.0f, 1.9f); // Vértice inf der
    glEnd();

    //Pentagono 6.0 (Lado Izq) Parte arriba
    glBegin(GL_POLYGON);
    glColor3f(1.0f, 0.0f, 0.0f); // Color rojo
    glVertex3f(-2.62f, 2.75f, 0.53f); // Vértice inf izq -D1
    //glColor3f(0.0f, 1.0f, 0.0f); // Color verde
    glVertex3f(-1.62f, 4.45f, 0.85f); // Vértice sup izq -G1
    //glColor3f(0.0f, 0.0f, 1.0f); // Color azul
    glVertex3f(0.0f, 4.45f, -0.32f); // Vértice sup der -L1
    //glColor3f(0.0f, 1.0f, 1.0f); // Color cian
    glVertex3f(-2.12f, 2.23f, -0.16f); // Vértice inf der -P2
    glEnd();

    //Pentagono 6.1 (Lado Der) Parte arriba
    glBegin(GL_POLYGON);
    glColor3f(0.0f, 1.0f, 1.0f); // Color cian
    glVertex3f(-1.62f, 1.7f, -0.85f); // Vértice inf der -B1
    //glColor3f(0.0f, 1.0f, 0.0f); // Color verde
    glVertex3f(-2.12f, 2.23f, -0.16f); // Vértice inf izq -P2
    //glColor3f(0.0f, 0.0f, 1.0f); // Color azul
    glVertex3f(0.0f, 4.45f, -0.32f); // Vértice sup izq -L1
    //glColor3f(1.0f, 0.0f, 0.0f); // Color rojo
    glVertex3f(0.0f, 2.75f, -1.38f); // Vértice sup der -M1
    glEnd();

    //Pentagono 7.0 (Lado Izq) Parte arriba
    glBegin(GL_POLYGON);
    glColor3f(0.0f, 0.0f, 1.0f); // Color azul
    glVertex3f(0.0f, 2.75f, -1.38f); // Vértice inf izq -M1
    glVertex3f(0.0f, 4.45f, -0.32f); // Vértice sup izq -L1
    glVertex3f(2.12f, 2.23f, -0.16f); // Vértice sup der -M2
    glVertex3f(1.62f,1.7f, -0.85f); // Vértice inf der -P1
    glEnd();

    //Pentagono 7.1 (Lado Der) Parte arriba
    glBegin(GL_POLYGON);
    glColor3f(1.0f, 0.0f, 0.0f); // Color rojo
    glVertex3f(2.12f, 2.23f, -0.16f); // Vértice inf izq -M2
    glVertex3f(0.0f, 4.45f, -0.32f); // Vértice sup izq -L1
    glVertex3f(1.62f, 4.45f, 0.85f); // Vértice inf izq -R1
    glVertex3f(2.62f, 2.75f, 0.53f); // Vértice inf der -S1
    glEnd();


    //Pentagono 8.0 (Lado Der) Parte arriba  (Rojo)
    glBegin(GL_POLYGON);
    glColor3f(1.0f, 1.0f, 1.0f);
    glVertex3f(2.62f, 2.75f, 0.53f); // Vértice inf izq -S1
    glVertex3f(1.62f, 4.45f, 0.85f); // Vértice sup izq -R1
    glVertex3f(2.12f, 2.23f, 2.92f); // Vértice inf der -O2
    glVertex3f(2.62f, 1.7f, 2.23f); // Vértice inf der -V1
    glEnd();

    //Pentagono 8.1 (Lado Der) Parte arriba
    glBegin(GL_POLYGON);
    glColor3f(1.0f, 0.0f, 1.0f); // Magenta (R=1, G=0, B=1)
    glVertex3f(2.12f, 2.23f, 2.92f); // Vértice inf izq -O2
    glVertex3f(1.62f, 4.45f, 0.85f); // Vértice sup izq -R1
    glVertex3f(1.0f, 4.45f, 2.75f); // Vértice inf izq -H1
    glVertex3f(1.62f, 2.75f, 3.6f); // Vértice inf der -C2
    glEnd();


    //Pentagono 9.0 (Lado Izq) Parte arriba 
    glBegin(GL_POLYGON);
    glColor3f(0.5f, 0.5f, 0.5f); // Gris (R=0.5, G=0.5, B=0.5)
    glVertex3f(1.62f, 2.75f, 3.6f); // Vértice inf izq -C2
    glVertex3f(1.0f, 4.45f, 2.75f); // Vértice sup izq -H1
    glVertex3f(0.0f, 4.45f, 2.75f); // Vértice sup der -L2
    glVertex3f(0.0f, 1.7f, 4.13f); // Vértice inf der -D2
    glEnd();

    //Pentagono 9.1 (Lado Izq) Parte arriba 
    glBegin(GL_POLYGON);
    glColor3f(1.0f, 1.0f, 0.0f); // Amarillo (R=1, G=1, B=0)
    glVertex3f(0.0f, 1.7f, 4.13f); // Vértice inf izq -D2
    glVertex3f(0.0f, 4.45f, 2.75f); // Vértice sup izq -L2
    glVertex3f(-1.0f, 4.45f, 2.75f); // Vértice inf izq -F1
    glVertex3f(-1.62f, 2.75f, 3.6f); // Vértice sup izq -N1
    glEnd();

    //Pentagono 10.0 (Lado Izq) Parte arriba 
    glBegin(GL_POLYGON);
    glColor3f(0.0f, 0.0f, 1.0f); // Azul (R=0, G=0, B=1)
    glVertex3f(-1.62f, 2.75f, 3.6f); // Vértice sup izq -E1
    glVertex3f(-1.0f, 4.45f, 2.75f); // Vértice inf izq -F1
    glVertex3f(-1.62f, 4.45f, 0.85f); // Vértice inf izq -K1
    glVertex3f(-2.12f, 2.23f, 2.92f); // Vértice sup izq -N2
    glEnd();

    //Pentagono 10.1 (Lado Izq) Parte arriba 
    glBegin(GL_POLYGON);
    glColor3f(1.0f, 1.0f, 0.0f); // Amarillo (R=1, G=1, B=0)
    glVertex3f(-2.12f, 2.23f, 2.92f); // Vértice sup izq -N2
    glVertex3f(-1.62f, 4.45f, 0.85f); // Vértice inf izq -K1
    glVertex3f(-2.62f, 2.75f, 0.53f); // Vértice sup izq -D1
    glVertex3f(-2.62f, 1.7f, 2.23f); // Vértice inf izq -C1
    glEnd();

    //Pentagono 0.3 (Base Izq SUPERIOR)
    glBegin(GL_POLYGON);
    glVertex3f(1.0f, 4.45f, 2.75f); // Vértice inf izq -h1
    glVertex3f(1.62f, 4.45f, 0.85f); // Vértice sup izq -R1
    glVertex3f(0.0f, 4.45f, -0.32f); // Vértice sup -L1
    glVertex3f(0.0f, 4.45f, 2.75f); // Vértice inf der -L2
    glEnd();

    //Pentagono 0.4 (Base Der SUPERIOR)
    glBegin(GL_POLYGON);
    glVertex3f(0.0f, 4.45f, 2.75f); // Vértice inf der -L2
    glVertex3f(0.0f, 4.45f, -0.32f); // Vértice sup -L1
    glVertex3f(-1.62f, 4.45f, 0.85f); // Vértice inf izq -G1
    glVertex3f(-1.0f, 4.45f, 2.75f); // Vértice sup izq -F1
    glEnd();
    glutSwapBuffers();  // Swap the front and back frame buffers (double buffering)
}

// Función de actualización de la cámara
void updateCamera(int value) {
    cameraAngle += 0.005f; // Ajusta la velocidad de rotación
    if (cameraAngle > 2 * 3.14) {
        cameraAngle -= 2 * 3.14;
    }

    glutPostRedisplay();
    glutTimerFunc(16, updateCamera, 0); // 60 FPS
}

/* Handler for window re-size event. Called back when the window first appears and
   whenever the window is re-sized with its new width and height */
void reshape(GLsizei width, GLsizei height) {  // GLsizei for non-negative integer
    // Compute aspect ratio of the new window
    if (height == 0) height = 1;                // To prevent divide by 0
    GLfloat aspect = (GLfloat)width / (GLfloat)height;

    // Set the viewport to cover the new window
    glViewport(0, 0, width, height);

    // Set the aspect ratio of the clipping volume to match the viewport
    glMatrixMode(GL_PROJECTION);  // To operate on the Projection matrix
    glLoadIdentity();             // Reset
    // Enable perspective projection with fovy, aspect, zNear and zFar
    gluPerspective(45.0f, aspect, 0.1f, 100.0f);
}

/* Main function: GLUT runs as a console application starting at main() */
int main(int argc, char** argv) {
    glutInit(&argc, argv);            // Initialize GLUT
    glutInitDisplayMode(GLUT_DOUBLE); // Enable double buffered mode
    glutInitWindowSize(640, 480);   // Set the window's initial width & height
    glutInitWindowPosition(50, 50); // Position the window's initial top-left corner
    glutCreateWindow(title);          // Create window with the given title
    glutDisplayFunc(display);       // Register callback handler for window re-paint event
    glutReshapeFunc(reshape);       // Register callback handler for window re-size event
    initGL();                       // Our own OpenGL initialization
    glutTimerFunc(0, updateCamera, 0);
    glutMainLoop();                 // Enter the infinite event-processing loop
    return 0;
}


