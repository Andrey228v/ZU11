using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    [SerializeField] private Transform _allPlacesPoint;
    [SerializeField] private float _speed;

    private List<Transform> _places;
    private int _placePointIndex = 0;
    private Transform _nextPlace;

    void Start()
    {
        _places = new List<Transform>();
        
        for (int i = 0; i < _allPlacesPoint.childCount; i++)
        {
            _places.Add(_allPlacesPoint.GetChild(i).GetComponent<Transform>());
        }

        _nextPlace = _places[_placePointIndex];
    }

    public void Update()
    {
        if (transform.position == _nextPlace.position)
            NextPoint();

        transform.position = Vector3.MoveTowards(transform.position, _nextPlace.position, _speed * Time.deltaTime);
    }
    public void NextPoint()
    {
        _placePointIndex = ++_placePointIndex % _places.Count;

        Vector3 nextPointPlace = _places[_placePointIndex].transform.position;
        transform.forward = nextPointPlace - transform.position;

        _nextPlace = _places[_placePointIndex];
    }
}
