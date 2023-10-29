using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IJoystickActivator
{
    [SerializeField] protected RectTransform _baseRect = null;
    [SerializeField] protected RectTransform _background = null;
    [SerializeField] private RectTransform _handle = null;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private float handleRange = 1;
    
    public Vector2 Input => _input;
    private Vector2 _input = Vector2.zero;
    private Camera cam;
    
    private void Start()
    {
        _background.gameObject.SetActive(false);
    }
    
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        _background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        _background.gameObject.SetActive(true);
        
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        cam = null;
        if (_canvas.renderMode == RenderMode.ScreenSpaceCamera)
            cam = _canvas.worldCamera;

        Vector2 position = RectTransformUtility.WorldToScreenPoint(cam, _background.position);
        Vector2 radius = _background.sizeDelta / 2;
        _input = (eventData.position - position) / (radius * _canvas.scaleFactor);
        HandleInput(_input.magnitude, _input.normalized, radius, cam);
        _handle.anchoredPosition = _input * radius * handleRange;
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        _background.gameObject.SetActive(false);
        
        _input = Vector2.zero;
        _handle.anchoredPosition = Vector2.zero;
    }
    
    protected virtual void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        if (magnitude > 1)
            _input = normalised;
    }
    
    protected Vector2 ScreenPointToAnchoredPosition(Vector2 screenPosition)
    {
        Vector2 localPoint = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_baseRect, screenPosition, cam, out localPoint))
        {
            Vector2 pivotOffset = _baseRect.pivot * _baseRect.sizeDelta;
            return localPoint - (_background.anchorMax * _baseRect.sizeDelta) + pivotOffset;
        }
        return Vector2.zero;
    }

    public void SetActive(bool isActive)
    {
        _input = Vector2.zero;
        gameObject.SetActive(isActive);
    }
}

//TODO : adjust obstacles count and positions
//TODO : collider enabler for enemies