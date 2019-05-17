
    private float pitch = 0.0f;

    public CursorLockMode wantedMode;
    {
        Cursor.lockState = wantedMode;
        Cursor.visible = (CursorLockMode.Locked != wantedMode);